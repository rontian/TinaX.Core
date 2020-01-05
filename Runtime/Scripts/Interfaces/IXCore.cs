﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinaX.Services;
using UnityEngine;

namespace TinaX
{
    public interface IXCore
    {
        #region Infos

        GameObject BaseGameObject { get; }

        string LocalStoragePath_TinaX { get; }
        string LocalStoragePath_App { get; }
        string FrameworkVersionName { get; }

        #endregion


        #region 依赖注入

        /// <summary>
        ///Get Service |  获取服务
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="userParams"></param>
        /// <returns></returns>
        TService GetService<TService>(params object[] userParams);

        /// <summary>
        /// Register a "TinaX Service Provider".
        /// 注册 TinaX 服务提供者
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        IXCore RegisterServiceProvider(IXServiceProvider provider);

        /// <summary>
        /// Bind Service. | 绑定服务
        /// </summary>
        /// <typeparam name="TService">服务接口</typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        void BindService<TService, TConcrete>();

        /// <summary>
        /// Bind a global singleton Service. | 绑定全局单例服务。
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        void BindSingletonService<TService, TConcrete>();

        /// <summary>
        /// Bind a global singleton Service , and implementation of framework built-in interface. | 绑定全局单例服务，并实现框架内置服务接口。
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <typeparam name="TBuiltInInterface"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        void BindSingletonService<TService, TBuiltInInterface, TConcrete>() where TBuiltInInterface : IBuiltInService;

        bool TryGetBuiltinService<TBuiltInInterface>(out TBuiltInInterface service) where TBuiltInInterface : IBuiltInService;

        /// <summary>
        /// 内置服务接口是否被实现
        /// </summary>
        /// <typeparam name="TBuiltInInterface"></typeparam>
        /// <returns></returns>
        bool IsBuiltInServicesImplementationed<TBuiltInInterface>() where TBuiltInInterface : IBuiltInService;


        #endregion

        Task RunAsync();

        Task CloseAsync();
    }
}