// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne

using BuilderPattern;

var command = "s";

var outputWriter = new OutputWriter();
var reportBuilder = new ReportBuilder(new BookRepository(), new MyDateTimeProvider());
var reportDirector = new ReportDirector(reportBuilder);

string report = reportDirector.CreateReportBasedOnParameters(command);
//reportDirector.CreateReportBasedOnParameters(command);
//var report = reportBuilder.Build();
outputWriter.Write(report);