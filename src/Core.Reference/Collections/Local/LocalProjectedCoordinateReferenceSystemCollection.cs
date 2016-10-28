﻿// <copyright file="LocalProjectedCoordinateReferenceSystemCollection.cs" company="Eötvös Loránd University (ELTE)">
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

namespace ELTE.AEGIS.Reference.Collections.Local
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using ELTE.AEGIS.Reference.Resources;

    /// <summary>
    /// Represents a collection of <see cref="ProjectedCoordinateReferenceSystem" /> instances.
    /// </summary>
    /// <remarks>
    /// This type queries references from local resources, which are specified according to the EPSG gedetic dataset format.
    /// </remarks>
    public class LocalProjectedCoordinateReferenceSystemCollection : LocalReferenceCollection<ProjectedCoordinateReferenceSystem>
    {
        #region Private constants

        /// <summary>
        /// The name of the resource. This field is constant.
        /// </summary>
        private const String ResourceName = "CoordinateReferenceSystem";

        /// <summary>
        /// The name of the alias type. This field is constant.
        /// </summary>
        private const String AliasTypeName = "Coordinate Reference System";

        #endregion

        #region Private fields

        /// <summary>
        /// The collection of  <see cref="AreaOfUse" /> instances.
        /// </summary>
        private IReferenceCollection<AreaOfUse> areaOfUseCollection;

        /// <summary>
        /// The collection of  <see cref="CoordinateProjection" /> instances.
        /// </summary>
        private ICoordinateProjectionCollection coordinateProjectionCollection;

        /// <summary>
        /// The collection of  <see cref="CoordinateSystem" /> instances.
        /// </summary>
        private IReferenceCollection<CoordinateSystem> coordinateSystemCollection;

        /// <summary>
        /// The collection of  <see cref="GeographicCoordinateReferenceSystem" /> instances.
        /// </summary>
        private IReferenceCollection<GeographicCoordinateReferenceSystem> baseCoordinateReferenceSystemCollection;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalProjectedCoordinateReferenceSystemCollection" /> class.
        /// </summary>
        /// <param name="areaOfUseCollection">The area of use collection.</param>
        /// <param name="coordinateProjectionCollection">The coordinate projection collection.</param>
        /// <param name="coordinateSystemCollection">The coordinate system collection.</param>
        /// <param name="baseReferenceSystemCollection">The base reference system collection.</param>
        /// <exception cref="System.ArgumentNullException">
        /// The area of use collection is null.
        /// or
        /// The coordinate projection collection is null.
        /// or
        /// The coordinate system collection is null.
        /// or
        /// The datum collection is null.
        /// or
        /// The base reference system collection is null.
        /// </exception>
        public LocalProjectedCoordinateReferenceSystemCollection(IReferenceCollection<AreaOfUse> areaOfUseCollection, ICoordinateProjectionCollection coordinateProjectionCollection,
                                                            IReferenceCollection<CoordinateSystem> coordinateSystemCollection, IReferenceCollection<GeographicCoordinateReferenceSystem> baseReferenceSystemCollection)
            : base(ResourceName, AliasTypeName)
        {
            if (areaOfUseCollection == null)
                throw new ArgumentNullException(nameof(areaOfUseCollection), Messages.AreaOfUseCollectionIsNull);
            if (coordinateProjectionCollection == null)
                throw new ArgumentNullException(nameof(coordinateProjectionCollection), Messages.CoordinateProjectionCollectionIsNull);
            if (coordinateSystemCollection == null)
                throw new ArgumentNullException(nameof(coordinateSystemCollection), Messages.CoordinateSystemCollectionIsNull);
            if (baseReferenceSystemCollection == null)
                throw new ArgumentNullException(nameof(baseReferenceSystemCollection), Messages.BaseReferenceSystemCollectionsIsNull);

            this.areaOfUseCollection = areaOfUseCollection;
            this.coordinateProjectionCollection = coordinateProjectionCollection;
            this.coordinateSystemCollection = coordinateSystemCollection;
            this.baseCoordinateReferenceSystemCollection = baseReferenceSystemCollection;
        }

        #endregion

        #region IProjectedCoordinateReferenceSystemCollection methods

        /// <summary>
        /// Returns a collection with items with the specified area of use.
        /// </summary>
        /// <param name="area">The area of use.</param>
        /// <returns>A collection containing the items that are with the specified area of use.</returns>
        /// <exception cref="System.ArgumentNullException">The area of use is null.</exception>
        public IEnumerable<ProjectedCoordinateReferenceSystem> WithArea(AreaOfUse area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area), Messages.AreaOfUseIsNull);

            return this.GetReferences().Where(referenceSystem => referenceSystem.AreaOfUse.Equals(area));
        }

        /// <summary>
        /// Returns a collection with items within the specified area of use.
        /// </summary>
        /// <param name="area">The area of use.</param>
        /// <returns>A collection containing the items that are within the specified area of use.</returns>
        /// <exception cref="System.ArgumentNullException">The area of use is null.</exception>
        public IEnumerable<ProjectedCoordinateReferenceSystem> WithinArea(AreaOfUse area)
        {
            if (area == null)
                throw new ArgumentNullException(nameof(area), Messages.AreaOfUseIsNull);

            return this.GetReferences().Where(referenceSystem => referenceSystem.AreaOfUse.Within(area));
        }

        /// <summary>
        /// Returns a collection with items matching a specified coordinate system.
        /// </summary>
        /// <param name="coordinateSystem">The coordinate system.</param>
        /// <returns>A collection containing the items that match the specified coordinate system.</returns>
        /// <exception cref="System.ArgumentNullException">The coordinate system is null.</exception>
        public IEnumerable<ProjectedCoordinateReferenceSystem> WithCoordinateSystem(CoordinateSystem coordinateSystem)
        {
            if (coordinateSystem == null)
                throw new ArgumentNullException(nameof(coordinateSystem), Messages.CoordinateSystemIsNull);

            return this.GetReferences().Where(referenceSystem => referenceSystem.CoordinateSystem.Equals(coordinateSystem));
        }

        /// <summary>
        /// Returns a collection with items matching a specified datum.
        /// </summary>
        /// <param name="datum">The geodetic datum.</param>
        /// <returns>A collection containing the items that match the specified datum.</returns>
        /// <exception cref="System.ArgumentNullException">The datum is null.</exception>
        public IEnumerable<ProjectedCoordinateReferenceSystem> WithDatum(GeodeticDatum datum)
        {
            if (datum == null)
                throw new ArgumentNullException(nameof(datum), Messages.DatumIsNull);

            return this.GetReferences().Where(referenceSystem => referenceSystem.Datum.Equals(datum));
        }

        /// <summary>
        /// Returns a collection with items matching a specified projection.
        /// </summary>
        /// <param name="projection">The coordinate projection.</param>
        /// <returns>A collection containing the items that match the specified projection.</returns>
        /// <exception cref="System.ArgumentNullException">The projection is null.</exception>
        public IEnumerable<ProjectedCoordinateReferenceSystem> WithProjection(CoordinateProjection projection)
        {
            if (projection == null)
                throw new ArgumentNullException(nameof(projection), Messages.ProjectionIsNull);

            return this.GetReferences().Where(referenceSystem => referenceSystem.Projection.Equals(projection));
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Converts the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns>The converted reference.</returns>
        protected override ProjectedCoordinateReferenceSystem Convert(String[] content)
        {
            switch (content[3])
            {
                case "projected":
                    AreaOfUse areaOfUse = this.areaOfUseCollection[Authority, Int32.Parse(content[2])];
                    GeographicCoordinateReferenceSystem baseReferenceSystem = this.baseCoordinateReferenceSystemCollection[Authority, Int32.Parse(content[6])];
                    CoordinateSystem coordinateSystem = this.coordinateSystemCollection[Authority, Int32.Parse(content[4])];
                    CoordinateProjection projection = this.coordinateProjectionCollection[Authority, Int32.Parse(content[7]), baseReferenceSystem.Datum.Ellipsoid.ToUnit(coordinateSystem.GetAxis(0).Unit)];

                    // the projection should use the ellipsoid with the unit specified by the coordinate system
                    // some projections are not supported (TODO: remove, once all projections are implemented)
                    if (projection == null)
                        return null;

                    return new ProjectedCoordinateReferenceSystem(IdentifiedObject.GetIdentifier(Authority, content[0]), content[1],
                                                                  content[11], this.GetAliases(Int32.Parse(content[0])), content[10],
                                                                  baseReferenceSystem, coordinateSystem, areaOfUse, projection);
                default:
                    return null;
            }
        }

        #endregion
    }
}