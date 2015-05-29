#load "../TestHelpers.fsx"
open TestHelpers
open System.IO
open System

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__
File.Delete "parsenosuchfile.txt"

let p = new FSharpAutoCompleteWrapper()

p.project "Project/Test1.fsproj"
p.send "parse \"NoSuchFile.fs\"\nBla bla bla\n<<EOF>>\n"
p.send "quit\n"
p.finalOutput ()
|> writeNormalizedOutput "parsenosuchfile.txt"

