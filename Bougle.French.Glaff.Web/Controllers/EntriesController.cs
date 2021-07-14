using Bougle.French.Glaff.Contracts;
using Bougle.French.Glaff.Storage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bougle.French.Glaff.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly GlaffDbContext _context;
        private readonly ILogger<EntriesController> _logger;

        public EntriesController(GlaffDbContext dbContext, ILogger<EntriesController> logger)
        {
            _context = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Return the entry with the given ID.
        /// </summary>
        /// <response code="200">The entry</response>
        /// <response code="404">Entry not found</response>
        [HttpGet("{entryId}")]
        [ProducesResponseType(typeof(GlaffEntryDto), 200)]
        public IActionResult GetEntry([FromRoute] int entryId)
        {
            var entry = _context.Entries.SingleOrDefault(e => e.Id == entryId);
            if (entry == null)
                return NotFound($"Entry not found for ID [{entryId}].");

            var dto = ToDto(entry);
            return Ok(dto);
        }


        private GlaffEntryDto ToDto(GlaffEntry entry)
        {
            return new GlaffEntryDto()
            {
                Id = entry.Id,
                GraphicalForm = entry.GraphicalForm,
                MorphoSyntax = entry.MorphoSyntax,
                Lemma = entry.Lemma,
                OldFashioned = entry.OldFashioned,
                Pronunciation = new PronunciationDto()
                {
                    Api = entry.ApiPronunciations.Split(";"),
                    Sampa = entry.SampaPronunciations.Split(";"),
                },
                Frequency = new FrequencyDto()
                {
                    Form = new FormFrequencyDto()
                    {
                        Absolute = new DatasetsFrequencyDto()
                        {
                            Frantex = entry.FrantexAbsoluteFormFrequency,
                            LM10 = entry.LM10AbsoluteFormFrequency,
                            FrWaC = entry.FrWacAbsoluteFormFrequency,
                        },
                        Relative = new DatasetsFrequencyDto()
                        {
                            Frantex = entry.FrantexRelativeFormFrequency,
                            LM10 = entry.LM10RelativeFormFrequency,
                            FrWaC = entry.FrWacRelativeFormFrequency,
                        },
                    },
                    Lemma = new FormFrequencyDto()
                    {
                        Absolute = new DatasetsFrequencyDto()
                        {
                            Frantex = entry.FrantexAbsoluteLemmaFrequency,
                            LM10 = entry.LM10AbsoluteLemmaFrequency,
                            FrWaC = entry.FrWacAbsoluteLemmaFrequency,
                        },
                        Relative = new DatasetsFrequencyDto()
                        {
                            Frantex = entry.FrantexRelativeLemmaFrequency,
                            LM10 = entry.LM10RelativeLemmaFrequency,
                            FrWaC = entry.FrWacRelativeLemmaFrequency,
                        },
                    },
                }
            };
        }
    }
}
