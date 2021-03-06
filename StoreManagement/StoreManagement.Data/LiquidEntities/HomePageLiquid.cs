﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotLiquid;
using StoreManagement.Data.Constants;
using StoreManagement.Data.Entities;

namespace StoreManagement.Data.LiquidEntities
{
    public class HomePageLiquid : BaseDrop
    {
        public List<FileManager> SliderImages;
        public List<Content> Blogs { get; set; }
        public List<Product> Products { get; set; }
        public List<Content> News { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }



        public int ImageHeightProduct { get; set; }
        public int ImageWidthProduct { get; set; }
        public List<ProductLiquid> ProductLiquidList
        {
            get
            {
                var list = new List<ProductLiquid>();

                foreach (var item in Products)
                {
                    var category = ProductCategories.FirstOrDefault(r => r.Id == item.ProductCategoryId);
                    if (category != null)
                    {
                        var blog = new ProductLiquid(item, category,  ImageWidthProduct, ImageHeightProduct);
                        list.Add(blog);
                    }
                }

                return list;
            }
        }
        public int ImageHeightSlider { get; set; }
        public int ImageWidthSlider { get; set; }
        public List<FileManagerLiquid> SliderImagesLiquid
        {
            get
            {
                var resultList = new List<FileManagerLiquid>();
                foreach (var sliderImage in SliderImages)
                {
                    var sliderLiquid = new FileManagerLiquid(sliderImage,  ImageWidthSlider, ImageHeightSlider);
                    resultList.Add(sliderLiquid);
                }

                return resultList;
            }
        }

        

        public int ImageHeightBlog { get; set; }
        public int ImageWidthBlog { get; set; }
        public List<ContentLiquid> BlogsLiquidList
        {
            get
            {
                var list = new List<ContentLiquid>();

                foreach (var item in Blogs)
                {
                    var category = Categories.FirstOrDefault(r => r.Id == item.CategoryId);
                    if (category != null)
                    {
                        var blog = new ContentLiquid(item, category,  StoreConstants.BlogsType, ImageWidthBlog, ImageHeightBlog);
                        list.Add(blog);
                    }
                }

                return list;
            }
        }

        public int ImageHeightNews { get; set; }
        public int ImageWidthNews { get; set; }
        public List<ContentLiquid> NewsLiquidList
        {
            get
            {
                var list = new List<ContentLiquid>();

                foreach (var item in Blogs)
                {
                    var category = Categories.FirstOrDefault(r => r.Id == item.CategoryId);
                    if (category != null)
                    {
                        var blog = new ContentLiquid(item, category,  StoreConstants.NewsType, ImageWidthNews, ImageHeightNews);
                        list.Add(blog);
                    }
                }

                return list;
            }
        }

        public List<ProductCategoryLiquid> ProductCategoriesLiquids
        {
            get
            {

                var cats = new List<ProductCategoryLiquid>();
                foreach (var item in ProductCategories)
                {
                    cats.Add(new ProductCategoryLiquid(item));
                }

                return cats;
            }
        }

        public List<CategoryLiquid> CategoriesLiquids
        {
            get
            {

                var cats = new List<CategoryLiquid>();
                foreach (var item in Categories)
                {
                    cats.Add(new CategoryLiquid(item,item.CategoryType));
                }

                return cats;
            }
        }


        public HomePageLiquid(PageDesign pageDesing, List<FileManager> sliderImages)
        {
         
            this.SliderImages = sliderImages;
        }


        


 





    }
}
