﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SystemFilter.PublicFilter
{
    public class SwaggerFileUploadFilter : IOperationFilter
    {
        public void Apply(Swashbuckle.AspNetCore.Swagger.Operation operation, OperationFilterContext context)
        {
            if (!context.ApiDescription.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase) &&
             !context.ApiDescription.HttpMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }
            var fileParameters = context.ApiDescription.ActionDescriptor.Parameters.Where(n => n.ParameterType == typeof(IFormFile)).ToList();
            if (fileParameters.Count < 0)
            {
                return;
            }
            operation.Consumes.Add("multipart/form-data");
            foreach (var fileParameter in fileParameters)
            {
                var parameter = operation.Parameters.Single(n => n.Name == fileParameter.Name);
                operation.Parameters.Remove(parameter);
                operation.Parameters.Add(new NonBodyParameter
                {
                    Name = parameter.Name,
                    In = "formData",
                    Description = parameter.Description,
                    Required = parameter.Required,
                    Type = "file"
                });
            }
        }
    }
}
