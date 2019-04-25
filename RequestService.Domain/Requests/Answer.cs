﻿using RequestService.Domain.SharedKernel;

namespace RequestService.Domain.Requests
{
    public class Answer : BaseEntity
    {
        public string TextTranslated { get; set; }
        public int RequestId { get; set; }
    }
}