// Copyright (c) 2020 Team Project: Lylat. All Rights Reserved.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish or distribute. This does not allow commercial distribution.
//
// This license does not cover any content made by Nintendo or any other commercial entity.
// Under this category fall the Arwing and the Wolfen model along with their respective assets, as well as the Star Fox trademark.
// Any commercial content has been used without permission.
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.IO;
using UnrealBuildTool;

public class Lylat : ModuleRules
{
	public string ProjectRoot { get { return Path.GetFullPath(ModuleDirectory + "../../../"); }}

	public Lylat(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = PCHUsageMode.UseExplicitOrSharedPCHs;

		PublicDependencyModuleNames.AddRange(new string[] { "Core", "CoreUObject", "Engine", "InputCore" });
		PrivateDependencyModuleNames.AddRange(new string[] { "Slate", "SlateCore" });

		string platform = "";
		string suffix = ".";

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			platform = "Win64";
			suffix += "dll.lib";
		}
		else if (Target.Platform == UnrealTargetPlatform.Mac)
		{
			platform = "Mac";
			suffix += "dylib";
		}
		else if (Target.Platform == UnrealTargetPlatform.Linux)
		{
			platform = "Linux";
			suffix += "so";
		}
		else throw new Exception("Unsupported platform");

		PublicIncludePaths.Add(ProjectRoot + "Source/Lylat/Discord");
		PublicAdditionalLibraries.Add(ProjectRoot + "Binaries/" + platform + "/discord_game_sdk" + suffix);
	}
}
