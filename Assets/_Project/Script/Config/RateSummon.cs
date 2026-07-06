using System.Collections;
using System.Collections.Generic;
using Core;
using Yade.Runtime;

namespace Tuna.Config
{
    public class RateSummonConfig
    {
        [DataField(0)] public int Id;
        [DataField(1)] public string Rarity;
        [DataField(2)] public int Level;
        [DataField(3)] public float Rate;
        [DataField(4)] public int Price;
    }
    public partial class GameConfig
    {
        public DictList<int, RateSummonConfig> NameDict;
        public IEnumerator LoadChapter(string nameConfig)
        {
            NameDict = LoadSheet(nameConfig).AsDictList<int, RateSummonConfig>(key => key.Id);
            yield return null;
        }
        public List<RateSummonConfig> LoadNameConfig(int id)
        {
            if (NameDict.TryGetValue(id, out var config))
                return config;
            return new List<RateSummonConfig>();
        }
    }
}