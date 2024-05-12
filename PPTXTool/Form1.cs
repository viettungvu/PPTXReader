using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPTXTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckTrueSlizeZoom();
            //Check("Test.pptx", 1, 3);
        }
        void setStatus(string text)
        {
            var parent = lblStatus.GetCurrentParent();
            if (parent.InvokeRequired)
            {
                parent.Invoke(new Action<System.Windows.Forms.Control>(c => lblStatus.Text = text), parent);
                return;
            }
            lblStatus.Text = text;
        }

        void setStatus(bool isSuccess, string text)
        {
            var parent = lblStatus.GetCurrentParent();
            if (parent.InvokeRequired)
            {
                parent.Invoke(new Action<System.Windows.Forms.Control>(c =>
                {
                    lblStatus.ForeColor = isSuccess ? Color.Green : Color.Red;
                    lblStatus.Text = text;
                }), parent);
                return;
            }
            lblStatus.ForeColor = isSuccess ? Color.Green : Color.Red;
            lblStatus.Text = text;
        }

        void CheckTrueSlizeZoom()
        {
            string pptxPath = txtFilePath.Text;
            if (string.IsNullOrWhiteSpace(pptxPath) || !System.IO.File.Exists(pptxPath))
            {
                setStatus(false, "File không tồn tại");
                return;
            }

            string ext = System.IO.Path.GetExtension(pptxPath);
            if (!string.Equals(ext, ".pptx", StringComparison.OrdinalIgnoreCase))
            {
                setStatus(false, "File đã chọn không phải định dạng .pptx");
                return;
            }

            int slideFrom = (int)txtSlideFrom.Value;
            int slideZoomTo = (int)txtSlideZoomTo.Value;

            if (slideFrom <= 0)
            {
                setStatus(false, "Slide bắt đầu phải là giá trị lớn hơn 0");
                return;
            }
            Check(pptxPath, slideFrom, slideZoomTo);
        }

        void Check(string pptxPath, int slideFrom, int slideZoomTo)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                setStatus("Đang kiểm tra");
                bool isTrueZoom = false;
                using (PresentationDocument presentationDocument = PresentationDocument.Open(pptxPath, false))
                {
                    PresentationPart presentationPart = presentationDocument.PresentationPart;
                    Presentation presentation = presentationPart.Presentation;
                    int totalSlides = presentation.SlideIdList.Count();
                    if (totalSlides <= 0)
                    {
                        setStatus(false, "Không tìm thấy slide nào trong tệp tin");
                        return;
                    }
                    if (slideZoomTo > totalSlides)
                    {
                        setStatus(false, string.Format("Vượt quá slide hiện có ({0})", totalSlides));
                        return;
                    }
                    int slideIndex = 1;
                    uint sldIdZoomTo = 0;

                    if (slideFrom <= slideZoomTo)
                    {
                        foreach (SlideId slideId in presentation.SlideIdList)
                        {
                            SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
                            Slide slide = slidePart.Slide;
                            if (slideIndex == slideFrom)
                            {
                                ///Check xem có hiệu ứng zoom không
                                var sldZmObj = slide.Descendants<OpenXmlUnknownElement>()
                                    .FirstOrDefault(it => it.LocalName == "sldZmObj");
                                if (sldZmObj != null)
                                {
                                    var sldIdAttr = sldZmObj.GetAttribute("sldId", "");
                                    if (sldIdAttr != null)
                                    {
                                        UInt32.TryParse(sldIdAttr.Value, out sldIdZoomTo);
                                        slideIndex += 1;
                                        continue;
                                    }
                                    break;
                                }
                                break;
                            }
                            if (slideIndex == slideZoomTo && slideId.Id.Value == sldIdZoomTo)
                            {
                                isTrueZoom = true;
                                break;
                            }
                            slideIndex += 1;
                        }
                    }
                    else
                    {
                        Dictionary<uint, int> sldIndexWithId = new Dictionary<uint, int>();
                        foreach (SlideId slideId in presentation.SlideIdList)
                        {
                            SlidePart slidePart = presentationPart.GetPartById(slideId.RelationshipId) as SlidePart;
                            Slide slide = slidePart.Slide;

                            UInt32.TryParse(slideId.Id, out uint id);
                            sldIndexWithId.Add(id, slideIndex);

                            if (slideIndex == slideFrom)
                            {
                                ///Check xem có hiệu ứng zoom không
                                var sldZmObj = slide.Descendants<OpenXmlUnknownElement>()
                                    .FirstOrDefault(it => it.LocalName == "sldZmObj");
                                if (sldZmObj != null)
                                {
                                    var sldIdAttr = sldZmObj.GetAttribute("sldId", "");
                                    if (sldIdAttr != null)
                                    {
                                        UInt32.TryParse(sldIdAttr.Value, out sldIdZoomTo);
                                        slideIndex += 1;
                                        continue;
                                    }
                                    break;
                                }
                                break;
                            }
                            slideIndex += 1;
                        }
                        isTrueZoom = sldIndexWithId.TryGetValue(sldIdZoomTo, out int index) && index == slideZoomTo;
                    }
                }
                setStatus(isTrueZoom, isTrueZoom ? "True" : "False");
            }
            catch (Exception ex)
            {
                setStatus(false, ex.Message);
            }

        }
    }
}
