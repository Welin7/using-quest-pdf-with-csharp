using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;

QuestPDF.Settings.License = LicenseType.Community;

// code in your main method
var document = Document.Create(container =>
{
    container.Page(page =>
    {
        // page content
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(s => s.FontSize(20));

        //header of page
        page.Header()
            .Text("Header of page")
            .SemiBold()
            .FontSize(50);

        //content of page
        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(c =>
            {
                c.Item()
                    .Text(Placeholders.LoremIpsum());

                c.Item()
                    .Image(Placeholders.Image(200, 100));
            });

        //footer of page view number pages
        page.Footer()
            .AlignCenter()
            .Text(f =>
            {
                f.Span("Page");
                f.CurrentPageNumber();
            });

    });
});

// instead of the standard way of generating a PDF file
document.GeneratePdf("arquivo.pdf");

// use the following invocation
document.ShowInPreviewer();

// optionally, you can specify an HTTP port to communicate with the previewer host (default is 12500)
document.ShowInPreviewer(12345);