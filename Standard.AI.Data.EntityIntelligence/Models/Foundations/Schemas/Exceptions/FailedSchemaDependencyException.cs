﻿// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standard.AI.Data.EntityIntelligence.Models.Foundations.Schemas.Exceptions
{
    internal class FailedSchemaDependencyException : Xeption
    {
        public FailedSchemaDependencyException(Exception innerException)
            : base(message: "Failed data dependency error ocurred, contact support.",
                  innerException)
        { }
    }
}