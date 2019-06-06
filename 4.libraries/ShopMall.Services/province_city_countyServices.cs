
	//----------province_city_county开始----------
    

using System;
using ShopMall.IServices;
using ShopMall.IRepository;
using ShopMall.Model.Models;
using ShopMall.Services.BASE;

namespace ShopMall.Services
{	
	/// <summary>
	/// province_city_countyServices
	/// </summary>	
	public class province_city_countyServices : BaseServices<province_city_county>, Iprovince_city_countyServices
    {
	
        Iprovince_city_countyRepository dal;
        public province_city_countyServices(Iprovince_city_countyRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
       
    }
}

	//----------province_city_county结束----------
	