﻿// Copyright (c) 2007-2017 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Primitives;
using osu.Game.Beatmaps;
using osu.Game.Screens.Select.Leaderboards;

namespace osu.Game.Screens.Select
{
    public class BeatmapDetailArea : Container
    {
        private readonly Container content;
        protected override Container<Drawable> Content => content;

        public readonly Container Details; //todo: replace with a real details view when added
        public readonly Leaderboard Leaderboard;

        private WorkingBeatmap beatmap;
        public WorkingBeatmap Beatmap
        {
            get
            {
                return beatmap;
            }
            set
            {
                beatmap = value;
                Leaderboard.Beatmap = beatmap?.BeatmapInfo;
            }
        }

        public BeatmapDetailArea()
        {
            AddInternal(new Drawable[]
            {
                new BeatmapDetailAreaTabControl
                {
                    RelativeSizeAxes = Axes.X,
                    OnFilter = (tab, mods) =>
                    {
                        switch (tab)
                        {
                            case BeatmapDetailTab.Details:
                                Details.Show();
                                Leaderboard.Hide();
                                break;
                            default:
                                Details.Hide();
                                Leaderboard.Show();
                                break;
                        }
                    },
                },
                content = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding { Top = BeatmapDetailAreaTabControl.HEIGHT },
                },
            });

            Add(new Drawable[]
            {
                Details = new Container
                {
                    RelativeSizeAxes = Axes.Both,
                },
                Leaderboard = new Leaderboard
                {
                    RelativeSizeAxes = Axes.Both,

                }
            });
        }
    }
}
