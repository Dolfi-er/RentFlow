export type TDocument = {
  id: string
  fileUrl: string
  name: string
  description: string
}

export type TDocumentForm = {
  file?: File
  name?: string
  description?: string
}
