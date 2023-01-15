﻿using Verse;

namespace NamedSubcores
{
    /// <summary>
    /// NamedSubcoreComp is added to SubcoreRegular and SubcoreHigh,
    /// allowing us to track the pawn that was scanned into the subcore.
    /// </summary>
    public class NamedSubcoreComp : ThingComp
    {
        /// <summary>
        /// PawnName tracks the name of the pawn scanned into the subcore.
        /// </summary>
        public Name PawnName;

        /// <summary>
        /// PostExposeData is used to save our component state.
        /// </summary>
        public override void PostExposeData()
        {
            Scribe_Deep.Look(ref PawnName, "pawnName");
            base.PostExposeData();
        }

        /// <summary>
        /// GetDescriptionPart adds to the item description.
        /// </summary>
        /// <returns></returns>
        public override string GetDescriptionPart()
        {
            string adjective = parent.def.defName switch
            {
                "SubcoreRegular" => "softscanned",
                "SubcoreHigh" => "ripscanned",
                _ => "scanned"
            };

            return "This subcore was " + adjective + " from " + PawnName;
        }

        /// <summary>
        /// CompInspectStringExtra adds to the item inspection pane.
        /// </summary>
        /// <returns></returns>
        public override string CompInspectStringExtra()
        {
            return "Pawn: " + PawnName;
        }
    }
}
