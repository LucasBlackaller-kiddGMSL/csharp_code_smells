cd..

dotnet build

cd Test.Console

echo "start: " %time%

"bin/Debug/net6.0/Test.Console.exe" tt0096754 jgorman
"bin/Debug/net6.0/Test.Console.exe" tt0060666 jgorman
"bin/Debug/net6.0/Test.Console.exe" tt0317303 jgorman

echo "end: " %time%