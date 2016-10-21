﻿// <copyright file="CoordinateSystemType.cs" company="Eötvös Loránd University (ELTE)">
//     Copyright 2016 Roberto Giachetta. Licensed under the
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

namespace ELTE.AEGIS.Reference
{
    /// <summary>
    /// Defines the types of coordinate systems.
    /// </summary>
    public enum CoordinateSystemType
    {
        /// <summary>
        /// Unknown coordinate system.
        /// </summary>
        Unknown,

        /// <summary>
        /// Affine coordinate system.
        /// </summary>
        Affine,

        /// <summary>
        /// Cartesian coordinate system.
        /// </summary>
        Cartesian,

        /// <summary>
        /// Cylindrical coordinate system.
        /// </summary>
        Cylindrical,

        /// <summary>
        /// Ellipsoidal coordinate system.
        /// </summary>
        Ellipsoidal,

        /// <summary>
        /// Linear coordinate system.
        /// </summary>
        Linear,

        /// <summary>
        /// Polar coordinate system.
        /// </summary>
        Polar,

        /// <summary>
        /// Spherical coordinate system.
        /// </summary>
        Spherical,

        /// <summary>
        /// User-defined coordinate system.
        /// </summary>
        UserDefined,

        /// <summary>
        /// Vertical coordinate system.
        /// </summary>
        Vertical,

        /// <summary>
        /// Temporal coordinate system.
        /// </summary>
        Temporal
    }
}
