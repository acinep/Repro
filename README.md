# Mvc_6934

Run 'SelfHost' console application and browse to http://localhost:9999/lib

* Expected result: rendering of embedded razor view from Lib assembly.
* Observed result: compilation error messages as per https://github.com/aspnet/Mvc/issues/6934

Included WebApplication - that directly references the web sdk - to show expected behavior
