using System;
using System.Collections.Generic;
using H3VRModInstaller.Models;

namespace H3VRModInstaller.Services
{
    public class Database
    {
        string test =
            "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. ";

        public IEnumerable<ModItem> GetItems() => new[]
        {
            new ModItem {Name = "KewlMod", Description = test, Version = Version.Parse("0.0.1")},
            new ModItem {Name = "JigglePhysics", Description = test, Version = Version.Parse("0.0.2")},
            new ModItem {Name = "BestHands Mod", Description = test, Version = Version.Parse("0.0.3")},
        };
    }
}