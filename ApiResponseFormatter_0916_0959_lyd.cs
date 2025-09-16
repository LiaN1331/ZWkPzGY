// 代码生成时间: 2025-09-16 09:59:34
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
# 增强安全性
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;

namespace ApiResponseFormatter
{
    /// <summary>
# NOTE: 重要实现细节
    /// 一个用于格式化API响应的工具类。
    /// </summary>
    public static class ApiResponseFormatter
    {
        /// <summary>
        /// 创建一个成功的API响应。
# 扩展功能模块
        /// </summary>
        /// <param name="result">成功的结果数据。</param>
        /// <param name="message">可选的成功消息。</param>
        /// <returns>一个格式化的API响应。</returns>
        public static IActionResult CreateSuccessResponse(object result, string message = "")
        {
            var response = new
            {
                Success = true,
                Message = message,
                Data = result
            };
            return new ObjectResult(response) { StatusCode = (int)HttpStatusCode.OK };
# 优化算法效率
        }

        /// <summary>
        /// 创建一个错误的API响应。
        /// </summary>
# 改进用户体验
        /// <param name="message">错误消息。</param>
# NOTE: 重要实现细节
        /// <param name="statusCode">HTTP状态码。</param>
        /// <returns>一个格式化的API响应。</returns>
        public static IActionResult CreateErrorResponse(string message, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            var response = new
            {
                Success = false,
                Message = message
            };
            return new ObjectResult(response) { StatusCode = statusCode };
        }

        /// <summary>
        /// 创建一个包含验证错误的API响应。
        /// </summary>
        /// <param name="modelState">模型状态字典，用于获取验证错误。</param>
# 优化算法效率
        /// <returns>一个格式化的API响应。</returns>
# 改进用户体验
        public static IActionResult CreateValidationResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
# 改进用户体验
            {
                var errors = new System.Collections.Generic.List<string>();
# FIXME: 处理边界情况
                foreach (var state in modelState)
                {
# 优化算法效率
                    if (!state.Value.ValidationState.Equals(Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Valid))
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                }
# NOTE: 重要实现细节
                return CreateErrorResponse(string.Join(", ", errors));
# 添加错误处理
            }
# 添加错误处理
            return CreateSuccessResponse(null);
        }
    }
}