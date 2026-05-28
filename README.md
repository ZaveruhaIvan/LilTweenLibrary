# 🥀💔 LilTween
**An allocation‑free alternative to DOTween**  
[![Unity](https://img.shields.io/badge/Unity-2020.3%2B-black?logo=unity)](https://unity.com)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

LilTween is a tiny, **zero‑allocation** tweening library for Unity that delivers the same fluent API you love from DOTween, but without any hidden garbage.  
No GC spikes, no per‑frame allocations – just smooth, predictable performance even on low‑end platforms.

## ✨ Why LilTween?
- **Zero allocations after initialization** – tweens are pooled and reused, so the GC stays asleep.
- **Familiar DOTween‑like syntax** – migrate with minimal code changes.
- **Up to 50% faster** in common scenarios (see benchmarks below).
- **All core tween types** – position, rotation, scale, color, alpha and more.
- **Unity 2020.3+ support** – works with all render pipelines and platforms.

## 🎥 See It in Action

### 🔄 Same Tweens, Zero Allocations
*Watch how LilTween performs identical animations while generating absolutely no garbage.*


https://github.com/user-attachments/assets/2a2e756b-fb4c-4185-bc78-82d620ed95c4


### ⚡ Performance vs DOTween
*Side‑by‑side profiler comparison: zero allocations, lower CPU usage*


https://github.com/user-attachments/assets/9757e4ec-fd8b-4004-b204-eea05a2ff103


> 📊 **Benchmark highlights** (optional table)  
> | Operation          | DOTween (alloc) | LilTween (alloc) |
> |-------------------|----------------|------------------|
> | 1000 tweens/frame | 0.6 MB          | **0 B**          |
> | CPU time (ms)     | 1.34            | **0.33**          |

## 🚀 Quick Start
```csharp
// Just like DOTween, but allocation‑free

rectTransform.ScaleRect(fromScale, targetScale, duration);
image.ChangeColor(targetColor, duration).WithDelay(delay);
