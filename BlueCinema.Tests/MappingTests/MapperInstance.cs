using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlueCinema.Tests.MappingTests
{
    public class MapperInstance
    {
        private static IMapper mapperInstance = null;
        private static object lockObject = new object();

        public static IMapper Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (mapperInstance == null)
                    {
                        Mapper.Initialize(cfg => cfg.AddProfile(new MappingProfile()));
                        mapperInstance = Mapper.Instance;
                        return mapperInstance;
                    }
                    else
                    {
                        return mapperInstance;
                    }
                }
            }
        }
    }
}
