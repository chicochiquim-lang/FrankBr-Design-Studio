# Sprint 006.1 — ViewportState

## Correção

O PanService anterior procurava `PanOffsetX` e `PanOffsetY`, propriedades
inexistentes em `CanvasState`, causando CS1061.

## Implementado

- `ViewportState` exclusivo para zoom e pan.
- `ZoomService` migrado para `ViewportState`.
- `PanService` migrado para `ViewportState`.
- `CanvasService` expõe o viewport compartilhado.
- `CanvasState` voltou a representar documento, grade, ponteiro e seleção.
- Sincronização dos offsets depois de zoom, ajuste e pan.
