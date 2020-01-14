using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Jetsons.JetPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikaOnDotNet.TextExtraction;

namespace Jetsons.JetPack
{
	
	public static class OfficeFilesText {


		/// <summary>
		/// Returns the plain text of the DOCX file using OpenXMLSDK
		/// 
		/// Code by Microsoft Corporation - https://code.msdn.microsoft.com/office/CSOpenXmlGetPlainText-554918c3/sourcecode?fileId=71592&pathId=851860130
		/// </summary>
		public static string LoadDOCXAsTextFast(this string filepath) {
			try {
				var package = WordprocessingDocument.Open(filepath, true);
				
				OpenXmlElement element = package.MainDocumentPart.Document.Body;
				if (element == null) {
					return "";
				}

				var text = GetPlainText(element).Trim();

				package.Dispose();

				return text;
			}
			catch (Exception) {
				return "";
			}
		}

		/// <summary> 
		/// Read Plain Text in all XmlElements of word document
		/// 
		/// Code by Microsoft Corporation - https://code.msdn.microsoft.com/office/CSOpenXmlGetPlainText-554918c3/sourcecode?fileId=71592&pathId=851860130
		/// </summary> 
		private static string GetPlainText(OpenXmlElement element) {
			StringBuilder PlainTextInWord = new StringBuilder();
			foreach (OpenXmlElement section in element.Elements()) {
				switch (section.LocalName) {
					// Text 
					case "t":
						PlainTextInWord.Append(section.InnerText);
						break;

					case "cr":  // Carriage return 
					case "br":  // Page break 
						PlainTextInWord.Append(Environment.NewLine);
						break;

					// Tab 
					case "tab":
						PlainTextInWord.Append("\t");
						break;

					// Paragraph 
					case "p":
						PlainTextInWord.Append(GetPlainText(section));
						PlainTextInWord.AppendLine(Environment.NewLine);
						break;

					default:
						PlainTextInWord.Append(GetPlainText(section));
						break;
				}
			}

			return PlainTextInWord.ToString();
		}

		/// <summary>
		/// Returns the plain text of the document using Tika, for slow but high-quality text extraction.
		/// Supports PDF, RTF, DOC, DOCX, XLS, XLSX, PPT, PPTX, ZIP (file listing), JPG (metadata).
		/// 
		/// Code from Tika - https://github.com/KevM/tikaondotnet
		/// </summary>
		private static string LoadDocumentAsText(this string path) {
			try {
				var textExtractor = new TextExtractor();

				var text = textExtractor.Extract(path).Text;

				return text.Trim();
			}
			catch (Exception) {
				return "";
			}
		}

		/// <summary>
		/// Returns the plain text of the RTF Document using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadRTFAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the Word DOC document using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadDOCAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the Word DOCX document using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadDOCXAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the PDF document using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadPDFAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the Excel XLS spreadsheet using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadXLSAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the Excel XLSX spreadsheet using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadXLSXAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the PowerPoint PPT presentation using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadPPTAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		/// <summary>
		/// Returns the plain text of the PowerPoint PPTX presentation using Tika, for slow but high-quality text extraction.
		/// </summary>
		public static string LoadPPTXAsText(this string path) {
			return path.LoadDocumentAsText();
		}
		

	}
}
