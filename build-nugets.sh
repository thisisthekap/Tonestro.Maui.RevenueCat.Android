#!/bin/bash
projects=$(cat ./projects.txt)

for project in ${projects}; do
	cd ${project}
	rm nugetoutput/*.nupkg
	dotnet clean -c Release
	dotnet restore
	dotnet build -c Release
	dotnet pack -c Release
	cd ..
done
./copy-nugets.sh
