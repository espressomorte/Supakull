﻿using System;
using System.Collections.Generic;

namespace SupakullTrackerServices
{
    [Serializable]
    public class TokenDTO
    {
        public TokenDTO()
        {
            Tokens = new List<TokenForSerialization>();
        }
        public  Int32 TokenId { get; set; }
        public  String TokenName { get; set; }
        public List<TokenForSerialization> Tokens { get; set; }
    }

    [Serializable]
    public class TokenForSerialization
    {
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
