// 代码生成时间: 2025-10-04 21:35:48
// SoundEffectManager.cs
// SoundEffectManager class is responsible for managing sound effects.

using System;
using System.Collections.Generic;
using System.IO;

namespace AudioManager
{
    // Exception class for sound effect manager
    public class SoundEffectException : Exception
    {
        public SoundEffectException(string message) : base(message)
        {
        }
    }

    // SoundEffectManager class manages the sound effects
    public class SoundEffectManager
    {
        private readonly Dictionary<string, SoundEffect> effects = new Dictionary<string, SoundEffect>();

        // Adds a sound effect to the manager
        public void AddSoundEffect(string name, string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new SoundEffectException($"Sound effect file not found: {filePath}");
                }

                using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    var soundEffect = new SoundEffect(fileStream);
                    effects[name] = soundEffect;
                }
            }
            catch (Exception ex)
            {
                throw new SoundEffectException($"Error adding sound effect: {ex.Message}");
            }
        }

        // Plays a sound effect
        public void PlaySoundEffect(string name)
        {
            if (!effects.TryGetValue(name, out var soundEffect))
            {
                throw new SoundEffectException($"Sound effect '{name}' not found.");
            }

            soundEffect.Play();
        }

        // Stops a sound effect
        public void StopSoundEffect(string name)
        {
            if (!effects.TryGetValue(name, out var soundEffect))
            {
                throw new SoundEffectException($"Sound effect '{name}' not found.");
            }

            soundEffect.Stop();
        }

        // Disposes of all sound effects
        public void Dispose()
        {
            foreach (var effect in effects.Values)
            {
                effect.Dispose();
            }
            effects.Clear();
        }
    }

    // SoundEffect class represents a sound effect
    public class SoundEffect : IDisposable
    {
        private readonly System.Media.SoundPlayer player;

        public SoundEffect(Stream soundStream)
        {
            player = new System.Media.SoundPlayer(soundStream);
        }

        public void Play()
        {
            player.Play();
        }

        public void Stop()
        {
            player.Stop();
        }

        public void Dispose()
        {
            player.Dispose();
        }
    }
}
