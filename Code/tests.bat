
set firstdir=%cd%
cd packages\xunit.runner.console.2.4.2\tools\net472\
set seconddir=%cd%
xunit.console %firstdir%\AdChimeProject.Tests\bin\Debug\AdChimeProject.Tests.dll
cd %firstdir%
pause