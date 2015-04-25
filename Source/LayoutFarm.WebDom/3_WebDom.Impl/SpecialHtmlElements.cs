﻿// 2015,2014 ,BSD, WinterDev  

using System;
using System.Collections.Generic;  
using LayoutFarm.WebDom;
using LayoutFarm.HtmlBoxes;
using LayoutFarm.UI; 
namespace LayoutFarm.WebDom.Impl
{
     
    sealed class HtmlRootElement : HtmlElement
    {
        public HtmlRootElement(HtmlDocument ownerDoc)
            : base(ownerDoc, 0, 0)
        {
        }
    }

  


    sealed class ShadowRootElement : HtmlElement
    {
        //note: this version is not conform with w3c  
        HtmlShadowDocument shadowDoc;
         
        public ShadowRootElement(HtmlDocument owner, int prefix, int localNameIndex)
            : base(owner, prefix, localNameIndex)
        {
            shadowDoc = new HtmlShadowDocument(owner);
            shadowDoc.SetDomUpdateHandler(owner.DomUpdateHandler);
        }
        public override bool HasCustomPrincipalBoxGenerator
        {
            get
            {
                return true;
            }
        } 
        public override void AddChild(DomNode childNode)
        {
            //add dom node to this node
            if (childNode.ParentNode != null)
            {
                throw new NotSupportedException("remove from its parent first");
            }
            shadowDoc.RootNode.AddChild(childNode);
        }
    }



}