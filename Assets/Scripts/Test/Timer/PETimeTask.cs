using System;
public class PETimeTask {
	public int tid;
    public Action callback;
	public double destTime;//单位：毫秒
	public double delay;
	public int count;
	public PETimeTask(int tid,Action callback,double destTime,double delay,int count){
		this.tid = tid;
		this.callback = callback;
		this.destTime = destTime;
		this.delay = delay;
		this.count = count;
	}
}
public class PEFrameTask {
    public int tid;
    public Action callback;
    public int destFrame;
    public int delay;
    public int count;

    public PEFrameTask(int tid, Action callback, int destFrame, int delay, int count) {
        this.tid = tid;
        this.callback = callback;
        this.destFrame = destFrame;
        this.delay = delay;
        this.count = count;
    }
}
public enum PETimeUnit{
	Millisecond,
	Second,
	Minute,
	Hour,
	Day
}