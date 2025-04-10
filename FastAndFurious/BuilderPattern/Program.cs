// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne

using BuilderPattern;

var command = "s";

var outputWriter = new OutputWriter();
var reportFactory = new ReportFactory(new BookRepository(), new MyDateTimeProvider());
var reportDirector = new ReportDirector(reportFactory);

string report = reportDirector.CreateReportBasedOnParameters(command);
outputWriter.Write(report);