export type TChat = TChatInfo & {
  messages: TMessage[]
}
export type TChatInfo = {
  id: string
  user: string
}

export type TMessage = {
  id: string
  datetime: string
  message: string
  sender: boolean
}
