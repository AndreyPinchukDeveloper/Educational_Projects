﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibrary.Models
{
    public class BasicSuggestionModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Suggestion { get; set; }
        public BasicSuggestionModel()
        {
            
        }
        public BasicSuggestionModel(SuggestionModel suggestion)
        {
            Id = suggestion.Id;
            Suggestion = suggestion.Suggestion;
        }
    }
}
