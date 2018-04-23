import { messageType } from "./messageType";

export interface responseMessage {
    fieldName?: string;
    message: string;
    messageType?: messageType;
}
