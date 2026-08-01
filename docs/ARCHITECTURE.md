# Arquitetura inicial

- `FrankBr.App`: interface WPF.
- `FrankBr.Core`: modelos e contratos centrais.
- `FrankBr.Canvas`: estado e regras do canvas 2D.
- `FrankBr.Rendering`: contratos de renderização.
- `FrankBr.Documents`: documentos `.frankbr`.
- `FrankBr.Templates`: catálogo e metadados de templates.
- `FrankBr.Infrastructure`: persistência e serviços do sistema.
- `FrankBr.Plugins`: contratos e carregamento de extensões.
- `FrankBr.Tests`: testes automatizados futuros.

O núcleo não depende de ETS2, ATS ou de um veículo específico.
