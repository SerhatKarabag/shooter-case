# 🚀 Shooter Case - Vuvy

<img align="right" width="180" src="Docs/Images/thumbnail.png" />

A *data-driven*, **GC-free** top-down shooter prototype built.

Focus areas:

* **Architecture** – Zenject (Extenject) DI, modular Installers, clean SRP
* **Patterns** – Decorator, Builder, Factory, Memory-Pool, State Machine
* **Performance** – 0 B Alloc / frame, pooled projectiles & players
* **Extensibility** – ScriptableObject power-ups; add a new ability with **no code**

---

## ✨ Gameplay

| Power-Up | Effect |
|----------|--------|
| **Spread**        | +45° side bullets (✕2) |
| **Double Shot**   | Fires two salvos “front/back” |
| **Rapid Fire**    | Halves fire-rate interval |
| **Fast Projectile** | ×1.5 bullet speed |
| **Clone**         | Spawns a fully-synced duplicate player |

> Only **three** abilities can be active at once.  
> Remaining buttons gray-out – UI fully driven by `PowerUpController` events.

---

## 🔧 Tech & Patterns

| Topic | Implementation | Why |
|-------|----------------|-----|
| **Dependency Injection** | **Zenject / Extenject** | Decoupled construction, unit-testable |
| **Object Pooling** | `BindMemoryPool<T>` for Shooter & Projectile | Zero GC; instant spawn |
| **Decorator** | `IShootingPattern` chain (Spread, Double, StatModifier) | Composable fire behaviours |
| **Builder** | `PatternBuilder` assembles decorators based on selected SOs | Data-driven, no `if` spaghetti |
| **State Machine** | `GameStateMachine` + `IGameState` (`MainMenu`, `Gameplay`) | Clean scene flow |
| **ScriptableObject** | `PowerUpConfig` + `EffectKind` | Easily add / tweak abilities via Inspector |
| **Signals (optional)** | `GameStateChangedSignal` stubbed | Future analytics / UI hooks |