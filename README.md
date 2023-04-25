# Welcome to LucidCLI!

This is my password manager program to store passwords in the terminal.

This software can be either run as a dotnet project or packed as a global tool.


# Global Tool Installation

1. cd into the directory of the project.
2. In the terminal run: 
  > dotnet pack
  
  > dotnet tool install --global --add-source ./nupkg Lucid

Or run...

  > dotnet publish -p:PublishSingleFile=true -r your-os -c Release --self-contained true
