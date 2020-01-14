# JetPack.Text for .NET

[![Version](https://img.shields.io/nuget/vpre/Jetsons.JetPack.Text.svg)](https://www.nuget.org/packages/Jetsons.JetPack.Text)
[![Downloads](https://img.shields.io/nuget/dt/Jetsons.JetPack.Text.svg)](https://www.nuget.org/packages/Jetsons.JetPack.Text)
[![GitHub contributors](https://img.shields.io/github/contributors/jetsons/JetPack.Text.Net.svg)](https://github.com/jetsons/JetPack.Text.Net/graphs/contributors)
[![License](https://img.shields.io/github/license/jetsons/JetPack.Text.Net.svg)](https://github.com/jetsons/JetPack.Text.Net/blob/master/LICENSE)

To use this simply grab our Nuget package `Jetsons.JetPack.Text` and add this to the top of your class:

    using Jetsons.JetPack.Text;
	
This statement unlocks all the extension methods below. Enjoy!

This library depends on the following Nuget packages:

- Jetsons.JetPack
- TikaOnDotNet
- DocumentFormat.OpenXml
	
### Extensions

Extension methods for file I/O performed using file path Strings:

- string.**LoadRTFAsText**
- string.**LoadDOCAsText**
- string.**LoadDOCXAsText**
- string.**LoadDOCXAsTextFast**
- string.**LoadPDFAsText**
- string.**LoadXLSAsText**
- string.**LoadXLSXAsText**
- string.**LoadPPTAsText**
- string.**LoadPPTXAsText**
