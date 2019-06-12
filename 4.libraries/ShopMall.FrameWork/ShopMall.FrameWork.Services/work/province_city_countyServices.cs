	//----------province_city_county开始----------
    

using System;
using ShopMall.FrameWork.IServices;
using ShopMall.FrameWork.IRepository;
using ShopMall.FrameWork.Entity;

namespace ShopMall.FrameWork.Services
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
	