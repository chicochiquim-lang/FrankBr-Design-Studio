# Sprint 006.1 — Correção V2

## Corrigido

- `MainWindowViewModel.ZoomText` agora usa `CanvasService.EffectiveZoom`.
- Eliminado o erro `CS1061` relacionado a `CanvasState.EffectiveZoom`.
- Confirmada ausência de referências antigas a `PanOffsetX` e `PanOffsetY`.
- Mantida a arquitetura com `ViewportState` compartilhado por Zoom e Pan.
