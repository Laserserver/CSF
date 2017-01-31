using System;

namespace Oop.Tasks.Paint.Engine
{

	public class PaintException: Exception
	{
		public PaintException(): base() {
    }


    public PaintException(string message): base(message) {
    }


    public PaintException(string message, Exception innerException):
               base(message, innerException) {
    }
	}
}
