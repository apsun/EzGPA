using System.Xml.Linq;
using EzGPA.Core;

namespace EzGPA.Config
{
    public class TemplateLoader
    {
        private readonly LevelTemplateLoader _levelTemplateLoader;
        private readonly ScoreTableLoader _scoreTemplateLoader;

        public TemplateLoader(XElement templatesElement)
        {
            XElement levelTemplateElement = templatesElement.Element("levels");
            XElement scoreTemplateElement = templatesElement.Element("scores");
            _levelTemplateLoader = new LevelTemplateLoader(levelTemplateElement);
            _scoreTemplateLoader = new ScoreTableLoader(scoreTemplateElement);
        }

        public LevelGroup[] BuildLevels(string levelTemplateNames)
        {
            return _levelTemplateLoader.Build(levelTemplateNames);
        }

        public ScoreTable BuildScoreTable(string scoreTableName)
        {
            return _scoreTemplateLoader[scoreTableName];
        }
    }
}
