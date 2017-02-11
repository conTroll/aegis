﻿// <copyright file="ITriangle.cs" company="Eötvös Loránd University (ELTE)">
//     Copyright 2016-2017 Roberto Giachetta. Licensed under the
//     Educational Community License, Version 2.0 (the "License"); you may
//     not use this file except in compliance with the License. You may
//     obtain a copy of the License at
//     http://opensource.org/licenses/ECL-2.0
//
//     Unless required by applicable law or agreed to in writing,
//     software distributed under the License is distributed on an "AS IS"
//     BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
//     or implied. See the License for the specific language governing
//     permissions and limitations under the License.
// </copyright>

namespace ELTE.AEGIS
{
    /// <summary>
    /// Defines behavior for triangle geometries.
    /// </summary>
    /// <remarks>
    /// A Triangle is a polygon with 3 distinct, non-collinear vertexes and no interior boundary.
    /// </remarks>
    public interface ITriangle : IPolygon
    {
    }
}
