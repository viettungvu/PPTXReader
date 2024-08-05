using DocumentFormat.OpenXml.Packaging;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Presentation;
using Transform2D = DocumentFormat.OpenXml.Drawing.Transform2D;
using System.Collections.Generic;
using System.Web;
using PPTXTool.Extensions;
using NonVisualGraphicFrameProperties = DocumentFormat.OpenXml.Presentation.NonVisualGraphicFrameProperties;
using NonVisualDrawingProperties = DocumentFormat.OpenXml.Presentation.NonVisualDrawingProperties;
using System.IO;

namespace PPTXTool
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCheckInk_Click(object sender, EventArgs e)
        {
            check("test2.pptx", "???");
        }

        void check(string filePath, string textToFind)
        {
            using (PresentationDocument presentationDocument = PresentationDocument.Open(filePath, false))
            {
                // Get the first slide
                SlidePart slidePart = presentationDocument.PresentationPart.SlideParts.FirstOrDefault(e => e.Uri.OriginalString.Contains("slide1.xml"));

                // Find all text elements and their positions
                var textElements = slidePart.Slide.Descendants<DocumentFormat.OpenXml.Drawing.Text>()
                    .Where(t => t.Text.Contains(textToFind))
                    .Select(t => new
                    {
                        Text = t.Text,
                        BoundingBox = GetBoundingBox(t)
                    }).ToList();

                // Find all ink elements and their positions
                var inkElements = slidePart.Slide.Descendants<NonVisualInkContentPartProperties>()
                    .Select(ink => new
                    {
                        Ink = ink,
                        BoundingBox = GetBoundingBox(ink)
                    }).ToList();

                // Check if any ink elements overlap with the text elements
                foreach (var textElement in textElements)
                {
                    foreach (var inkElement in inkElements)
                    {
                        if (IsOverlapping(textElement.BoundingBox, inkElement.BoundingBox))
                        {
                            Console.WriteLine($"The text \"{textToFind}\" is overlapped by an ink annotation.");
                        }
                    }
                }
            }
        }
        private (double X, double Y, double Width, double Height) GetBoundingBox(DocumentFormat.OpenXml.OpenXmlElement element)
        {
            var parentShape = element.Ancestors<DocumentFormat.OpenXml.Presentation.Shape>().FirstOrDefault();

            if (parentShape != null)
            {
                var transform = parentShape.Descendants<Transform2D>().FirstOrDefault();
                if (transform != null)
                {
                    var offset = transform.Offset;
                    var extents = transform.Extents;
                    if (offset != null && extents != null)
                    {
                        return (offset.X, offset.Y, extents.Cx, extents.Cy);
                    }
                }
            }
            return (0, 0, 0, 0);
        }

        private bool IsOverlapping((double X, double Y, double Width, double Height) box1, (double X, double Y, double Width, double Height) box2)
        {
            return !(box1.X + box1.Width < box2.X ||
                     box1.X > box2.X + box2.Width ||
                     box1.Y + box1.Height < box2.Y ||
                     box1.Y > box2.Y + box2.Height);
        }

        private void btnGetAnimate_Click(object sender, EventArgs e)
        {
            GetAnimate("test3.pptx");
        }

        void GetAnimate(string filePath)
        {
            using (PresentationDocument presentationDocument = PresentationDocument.Open(filePath, false))
            {
                // Get the first slide
                SlidePart slidePart = presentationDocument.PresentationPart.SlideParts.FirstOrDefault(e => e.Uri.OriginalString.Contains("slide3.xml"));

                // Get the timeline element of the slide, which contains animations
                var timeLine = slidePart.Slide.Timing;

                if (timeLine != null)
                {
                    // Get the common time nodes which represent animations
                    var animations = timeLine.Descendants<CommonTimeNode>().ToList();

                    foreach (var animation in animations)
                    {
                        // Get the name of the animation
                        var animationName = GetAnimationName(animation);
                        Console.WriteLine(animationName);
                        //// Find the associated target element (e.g., shape)
                        //var targetElement = GetTargetElement(slidePart, animation);

                        //if (targetElement != null)
                        //{
                        //    Console.WriteLine($"Animation: {animationName}");
                        //    Console.WriteLine($"Target Element: {targetElement}");
                        //}
                    }
                }
            }
        }
        private static string GetAnimationName(CommonTimeNode animation)
        {
            // Look for the animation type in the child elements of the animation node
            var commonBehavior = animation.Descendants<CommonBehavior>().FirstOrDefault();
            if (commonBehavior != null)
            {
                // Check for specific animation types
                if (commonBehavior is DocumentFormat.OpenXml.Presentation.SetBehavior)
                {
                    return "Set";
                }
                if (commonBehavior is DocumentFormat.OpenXml.Presentation.AnimateScale)
                {
                    return "Animate Motion";
                }
                if (commonBehavior is DocumentFormat.OpenXml.Presentation.AnimateRotation)
                {
                    return "Animate Scale";
                }
                if (commonBehavior is DocumentFormat.OpenXml.Presentation.Animate)
                {
                    return "Animate Rotation";
                }
                //if (commonBehavior is DocumentFormat.OpenXml.Presentation.)
                //{
                //    return "Command";
                //}

                // Other specific behaviors can be checked here...
            }

            //var animationString = animation.Descendants<CommonBehavior>().SelectMany(b => b.AnimateMotionBehavior).FirstOrDefault();
            //if (animationString != null && animationString.AttributeName == "Jump & Turn")
            //{
            //    return "Jump & Turn";
            //}

            return "Unknown Animation";
        }

        private static string GetTargetElement(SlidePart slidePart, CommonTimeNode animation)
        {
            //// Extract the target element ID from the animation
            //var targetElementId = animation.Descendants<DocumentFormat.OpenXml.Presentation.TargetElement>().FirstOrDefault()?.ElementId;

            //if (!string.IsNullOrEmpty(targetElementId))
            //{
            //    // Find the element in the slide with the matching ID
            //    var targetElement = slidePart.Slide.Descendants<Shape>().FirstOrDefault(shape => shape.NonVisualShapeProperties.NonVisualDrawingProperties.Id == targetElementId);

            //    if (targetElement != null)
            //    {
            //        return targetElement.NonVisualShapeProperties.NonVisualDrawingProperties.Name;
            //    }
            //}

            return null;
        }

        private void btnCheckZoom_Click(object sender, EventArgs e)
        {
            string filePath = @"test3.pptx";
            var output = checkZoom(filePath);
        }

        private List<KeyValuePair<string, string>> checkZoom(string filePath)
        {
            List<KeyValuePair<string, string>> output = new List<KeyValuePair<string, string>>();
            if (System.IO.File.Exists(filePath))
            {
                ///Để tránh xung đột trong quá trình xử lý file thì cần copy file ra một thư mục khác và lý nghiệp vụ trên file đã copy, không xử lý trên file gốc
                ///
                string dir = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(filePath), "_tmp");
                if (!Directory.Exists(dir))
                {
                    try
                    {
                        ///Tạo thư mục tmp nếu chưa có
                        Directory.CreateDirectory(dir);
                    }
                    catch (Exception)
                    {
                        return output;
                    }
                }
                string desFile = System.IO.Path.Combine(dir, System.IO.Path.GetFileName(filePath));
                try
                {
                    ///Copy file sang thư mục _temp
                    System.IO.File.Copy(filePath, desFile);

                    using (PresentationDocument presentationDocument = PresentationDocument.Open(desFile, false))
                    {
                        PresentationPart presentationPart = presentationDocument.PresentationPart;
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        IEnumerable<Section> sections = presentationPart.Presentation.Descendants<Section>();
                        foreach (var section in sections)
                        {
                            dic.Add(section.Attribute("id"), section.Attribute("name"));
                        }

                        const string URI = "http://schemas.microsoft.com/office/powerpoint/2016/sectionzoom";
                        foreach (var slidePart in presentationPart.SlideParts)
                        {
                            try
                            {
                                Slide slide = slidePart.Slide;
                                var graphicContainZoom = slide.Descendants<GraphicData>().Where(e =>
                                {
                                    return string.Equals(e.Attribute("uri"), URI);
                                });
                                foreach (var graphic in graphicContainZoom)
                                {
                                    var sectionZmObj = graphic.Descendants<OpenXmlUnknownElement>()
                                     .Where(e => e.LocalName.Equals("sectionZmObj")).FirstOrDefault();

                                    if (sectionZmObj != null)
                                    {
                                        string sectionId = sectionZmObj.Attribute("sectionId");
                                        if (dic.TryGetValue(sectionId, out string targetSection))
                                        {
                                            var nvGraphicFramePr = graphic.Parent.PreviousSibling<NonVisualGraphicFrameProperties>();
                                            if (nvGraphicFramePr != null)
                                            {
                                                var cNvpr = nvGraphicFramePr.GetFirstChild<NonVisualDrawingProperties>();
                                                string zoomSectionName = cNvpr.Attribute("name");
                                                output.Add(new KeyValuePair<string, string>(zoomSectionName, targetSection));
                                            }
                                            else
                                            {
                                                output.Add(new KeyValuePair<string, string>("", targetSection));
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {

                            }

                        }
                    }

                }
                catch (Exception)
                {

                }
                finally
                {
                    ///Sau khi làm xong thì xóa file đã copy đi
                    if (File.Exists(desFile))
                    {
                        try
                        {
                            System.IO.File.Delete(desFile);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
            return output;
        }
    }
}
