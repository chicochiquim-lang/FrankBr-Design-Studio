# ADR-001 — EditorEngine como núcleo do sistema

## Status
Aceito — Sprint 004 / FB-004.

## Contexto
O FrankBr já possui `FrankCanvas`, `CanvasService`, `CanvasState` e `GridLayer`.
A interface não deve se tornar o ponto de acoplamento entre documentos,
ferramentas, histórico, IA e plugins.

## Decisão
Criar um projeto puro `.NET 8` chamado `FrankBr.Engine`.
O `EditorEngine` coordena módulos por contratos sem depender de WPF.
O `CanvasService` da aplicação implementa `ICanvasModule` e é injetado na Engine.

## Consequências
- A Engine não referencia `FrankBr.App`.
- A interface pode ser substituída no futuro sem reescrever o núcleo.
- O Canvas atual continua funcionando sem alteração visual.
- Zoom, pan, comandos e histórico poderão entrar como módulos incrementais.
