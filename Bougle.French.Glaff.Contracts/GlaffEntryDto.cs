using System;

namespace Bougle.French.Glaff.Contracts
{
    public class GlaffEntryDto
    {
        public int Id { get; set; }
        public string GraphicalForm { get; set; }
        public string MorphoSyntax { get; set; }
        public string Lemma { get; set; }
        public bool OldFashioned { get; set; }
        public PronunciationDto Pronunciation { get; set; }
        public FrequencyDto Frequency { get; set; }
    }

    public class PronunciationDto
    {
        public string[] Api { get; set; }
        public string[] Sampa { get; set; }
    }

    public class FrequencyDto
    {
        public FormFrequencyDto Form { get; set; }
        public FormFrequencyDto Lemma { get; set; }
    }

    public class FormFrequencyDto
    {
        public DatasetsFrequencyDto Absolute { get; set; }
        public DatasetsFrequencyDto Relative { get; set; }
    }

    public class DatasetsFrequencyDto
    {
        public double Frantex { get; set; }
        public double LM10 { get; set; }
        public double FrWaC { get; set; }
    }
}
