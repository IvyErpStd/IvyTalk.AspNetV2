﻿namespace IvyTalk.AspNet.Formatting
{
    internal enum MediaTypeHeaderValueRange
    {
        /// <summary>
        /// Not a media type range
        /// </summary>
        None = 0,

        /// <summary>
        /// A subtype media range, e.g. "application/*".
        /// </summary>
        SubtypeMediaRange,

        /// <summary>
        /// An all media range, e.g. "*/*".
        /// </summary>
        AllMediaRange,
    }
}