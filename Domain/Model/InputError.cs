﻿namespace Domain.Model
{
    public class InputError
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return Message;
        }
    }
}
