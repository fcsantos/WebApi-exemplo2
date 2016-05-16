using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Web.Mappers
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(
                m =>
                {
                    m.AddProfile<EntityToModelMapping>();
                    m.AddProfile<ModelToEntityMapping>();
                }
            );
        }
    }
}
