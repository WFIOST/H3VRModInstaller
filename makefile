SHELL            = /bin/bash

GIT_BRANCH       = $(shell git rev-parse --abbrev-ref HEAD)
GIT_HASH         = $(shell git rev-parse HEAD)

PROJECT          = H3VRModInstaller

CONFIG           = Debug
FRAMEWORK        = net5.0
BUILD_PROPERTIES = /p:RepositoryBranch="$(GIT_BRANCH)" /p:RepositoryCommit="$(GIT_HASH)"

.PHONY: build

build:
	dotnet publish -r win-x64 -p:PublishSingleFile=true --self-contained false