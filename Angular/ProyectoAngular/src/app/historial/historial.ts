export interface IHistorial {
    id: string
    importe: number
    monedaOrigenId: string
    monedaDestinoId: string
    codigoMonedaOrigen: string
    codigoMonedaDestino: string
    idUsuario: string
    factor: number
    resultadoConversion: number
    createdDate: Date
}