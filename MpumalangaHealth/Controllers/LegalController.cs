using Microsoft.AspNetCore.Mvc;
using MpumalangaHealth.Models;

namespace MpumalangaHealth.Controllers
{
    public class LegalController : Controller
    {
        public IActionResult Accessibility()
        {
            var page = new LegalPage
            {
                Title = "Accessibility Statement",
                Content = GetAccessibilityContent(),
                LastUpdated = DateTime.Now
            };
            return View(page);
        }

        public IActionResult Disclaimer()
        {
            var page = new LegalPage
            {
                Title = "Disclaimer",
                Content = GetDisclaimerContent(),
                LastUpdated = DateTime.Now
            };
            return View(page);
        }

        public IActionResult Privacy()
        {
            var page = new LegalPage
            {
                Title = "Privacy Policy",
                Content = GetPrivacyContent(),
                LastUpdated = DateTime.Now
            };
            return View(page);
        }

        public IActionResult Terms()
        {
            var page = new LegalPage
            {
                Title = "Terms of Use",
                Content = GetTermsContent(),
                LastUpdated = DateTime.Now
            };
            return View(page);
        }

        private string GetAccessibilityContent()
        {
            return @"
<h3>Commitment to Accessibility</h3>
<p>The Mpumalanga Department of Health is committed to ensuring that our website is accessible to all users, including those with disabilities. We strive to adhere to Web Content Accessibility Guidelines (WCAG) 2.1 Level AA standards.</p>

<h4>Accessibility Features</h4>
<ul>
    <li>Alternative text for all images</li>
    <li>Keyboard navigation support</li>
    <li>Clear and consistent navigation</li>
    <li>Responsive design for various devices</li>
    <li>Readable font sizes and color contrast</li>
</ul>

<h4>Feedback</h4>
<p>If you experience any accessibility barriers on our website, please contact us:</p>
<p>Email: <a href='mailto:accessibility@mpuhealth.gov.za'>accessibility@mpuhealth.gov.za</a><br>
Phone: 013 766 3000</p>

<h4>Continuous Improvement</h4>
<p>We regularly review and update our website to improve accessibility for all users.</p>";
        }

        private string GetDisclaimerContent()
        {
            return @"
<h3>Website Disclaimer</h3>
<p>The information contained on this website is for general information purposes only. The Mpumalanga Department of Health endeavours to keep the information up to date and correct, however we make no representations or warranties of any kind, express or implied, about the completeness, accuracy, reliability, suitability or availability with respect to the website or the information, products, services, or related graphics contained on the website for any purpose.</p>

<h4>Medical Information</h4>
<p>This website provides health information for educational purposes only. It is not intended as medical advice. For specific medical concerns, please consult a qualified healthcare professional.</p>

<h4>External Links</h4>
<p>Our website may contain links to external websites that are not provided or maintained by us. We do not guarantee the accuracy, relevance, timeliness, or completeness of any information on these external websites.</p>

<h4>Liability</h4>
<p>In no event will the Mpumalanga Department of Health be liable for any loss or damage including without limitation, indirect or consequential loss or damage, or any loss or damage whatsoever arising from loss of data or profits arising out of, or in connection with, the use of this website.</p>";
        }

        private string GetPrivacyContent()
        {
            return @"
<h3>Privacy Policy</h3>
<p>This privacy policy explains how the Mpumalanga Department of Health collects, uses, and protects your personal information when you use our website.</p>

<h4>Information We Collect</h4>
<ul>
    <li>Personal information you voluntarily provide through forms</li>
    <li>Website usage data through analytics</li>
    <li>Contact information when you communicate with us</li>
</ul>

<h4>How We Use Your Information</h4>
<ul>
    <li>To provide services and information you request</li>
    <li>To improve our website and services</li>
    <li>To respond to your inquiries</li>
    <li>To comply with legal obligations</li>
</ul>

<h4>Information Protection</h4>
<p>We implement appropriate security measures to protect your personal information against unauthorized access, alteration, disclosure, or destruction.</p>

<h4>Your Rights</h4>
<p>You have the right to access, correct, or delete your personal information. Contact us at <a href='mailto:privacy@mpuhealth.gov.za'>privacy@mpuhealth.gov.za</a> to exercise these rights.</p>";
        }

        private string GetTermsContent()
        {
            return @"
<h3>Terms of Use</h3>
<p>By using this website, you accept these terms of use in full. If you disagree with these terms, you must not use this website.</p>

<h4>Intellectual Property</h4>
<p>All content on this website, unless otherwise stated, is the property of the Mpumalanga Provincial Government and is protected by copyright laws.</p>

<h4>Permitted Use</h4>
<p>You may view, download, and print pages from the website for your own personal use, subject to the restrictions set out below.</p>

<h4>Restrictions</h4>
<p>You must not:</p>
<ul>
    <li>Republish material from this website without permission</li>
    <li>Sell, rent, or sub-license material from the website</li>
    <li>Show any material from the website in public without permission</li>
    <li>Use this website in any way that causes damage to the website or impairment of availability</li>
</ul>

<h4>Updates</h4>
<p>We may revise these terms of use from time to time. Please check this page regularly to ensure you are familiar with the current version.</p>";
        }
    }
}