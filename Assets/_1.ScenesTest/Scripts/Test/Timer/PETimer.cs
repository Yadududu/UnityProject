using System;
using System.Collections.Generic;

public class PETimer{
    private Action<string> taskLog;
    private static readonly string obj = "lock";
    private DateTime startDateTime = new DateTime(1970,1,1,0,0,0,0);
    private double nowTime;
    private int tid;
    private List<int> tidLst = new List<int>();
    private List<int> recTidLst = new List<int>();

    private List<PETimeTask> tmpTimeLst = new List<PETimeTask>();
    private List<PETimeTask> taskTimeLst = new List<PETimeTask>();

    private int frameCounter;
    private List<PEFrameTask> tmpFrameLst = new List<PEFrameTask>();
    private List<PEFrameTask> taskFrameLst = new List<PEFrameTask>();

    public PETimer() {
        tidLst.Clear();
        recTidLst.Clear();

        tmpTimeLst.Clear();
        taskTimeLst.Clear();

        tmpFrameLst.Clear();
        taskFrameLst.Clear();
    }
    public void Update() {
        CheckTimeTask();
        CheckFrameTask();
        if (recTidLst.Count > 0) {
            RecycleTid();
        }
    }
    private void CheckTimeTask() {
        //加入缓存区中的定时任务
        for (int tmpIndex = 0; tmpIndex < tmpTimeLst.Count; tmpIndex++) {
            taskTimeLst.Add(tmpTimeLst[tmpIndex]);
        }
        tmpTimeLst.Clear();
        //遍历检测任务是否达到条件
        nowTime = GetUTCMilliseconds();
        for (int index = 0; index < taskTimeLst.Count; index++) {
            PETimeTask task = taskTimeLst[index];
            if (nowTime.CompareTo(task.destTime) < 0) {
                continue;
            } else {
                Action cb = task.callback;
                try {
                    if (cb != null) {
                        cb();
                    }
                } catch (Exception e) {
                    LogInfo(e.ToString());
                }

                //移除已经完成的任务
                if (task.count == 1) {
                    taskTimeLst.RemoveAt(index);
                    index--;
                    recTidLst.Add(task.tid);
                } else {
                    if (task.count != 0) {
                        task.count -= 1;
                    }
                    task.destTime += task.delay;
                }
            }
        }
    }
    private void CheckFrameTask() {
        //加入缓存区中的定时任务
        for (int tmpIndex = 0; tmpIndex < tmpFrameLst.Count; tmpIndex++) {
            taskFrameLst.Add(tmpFrameLst[tmpIndex]);
        }
        tmpFrameLst.Clear();
        frameCounter += 1;
        //遍历检测任务是否达到条件
        for (int index = 0; index < taskFrameLst.Count; index++) {
            PEFrameTask task = taskFrameLst[index];
            if (frameCounter < task.destFrame) {
                continue;
            } else {
                Action cb = task.callback;
                try {
                    if (cb != null) {
                        cb();
                    }
                } catch (Exception e) {
                    LogInfo(e.ToString());
                }

                //移除已经完成的任务
                if (task.count == 1) {
                    taskFrameLst.RemoveAt(index);
                    index--;
                    recTidLst.Add(task.tid);
                } else {
                    if (task.count != 0) {
                        task.count -= 1;
                    }
                    task.destFrame += task.delay;
                }
            }
        }
    }
    #region TimeTask
    public int AddTimeTask(Action callback, double delay, int count = 1, PETimeUnit timeUnit = PETimeUnit.Millisecond) {
        if (timeUnit != PETimeUnit.Millisecond) {
            switch (timeUnit) {
                case PETimeUnit.Second:
                    delay = delay * 1000;
                    break;
                case PETimeUnit.Minute:
                    delay = delay * 1000 * 60;
                    break;
                case PETimeUnit.Hour:
                    delay = delay * 1000 * 60 * 60;
                    break;
                case PETimeUnit.Day:
                    delay = delay * 1000 * 60 * 60 * 24;
                    break;
                default:
                    LogInfo("Add Task TimeUniy Type Error...");
                    break;

            }
        }
        int tid = GetTid();
        nowTime = GetUTCMilliseconds();
        tmpTimeLst.Add(new PETimeTask(tid, callback, nowTime + delay, delay, count));
        tidLst.Add(tid);
        return tid;
    }
    public bool DeleteTimeTask(int tid) {
        bool exist = false;
        for (int i = 0; i < taskTimeLst.Count; i++) {
            PETimeTask task = taskTimeLst[i];
            if (task.tid == tid) {
                taskTimeLst.RemoveAt(i);
                for (int j = 0; j < tidLst.Count; j++) {
                    if (tidLst[j] == tid) {
                        tidLst.RemoveAt(j);
                        break;
                    }
                }
                exist = true;
                break;
            }
        }

        if (!exist) {
            for (int i = 0; i < tmpTimeLst.Count; i++) {
                PETimeTask task = tmpTimeLst[i];
                if (task.tid == tid) {
                    tmpTimeLst.RemoveAt(i);
                    for (int j = 0; j < tidLst.Count; j++) {
                        if (tidLst[j] == tid) {
                            tidLst.RemoveAt(j);
                            break;
                        }
                    }
                    exist = true;
                    break;
                }
            }
        }
        return exist;
    }
    public bool ReplaceTimeTask(int tid, Action callback, float delay, int count = 1, PETimeUnit timeUnit = PETimeUnit.Millisecond) {
        if (timeUnit != PETimeUnit.Millisecond) {
            switch (timeUnit) {
                case PETimeUnit.Second:
                    delay = delay * 1000;
                    break;
                case PETimeUnit.Minute:
                    delay = delay * 1000 * 60;
                    break;
                case PETimeUnit.Hour:
                    delay = delay * 1000 * 60 * 60;
                    break;
                case PETimeUnit.Day:
                    delay = delay * 1000 * 60 * 60 * 24;
                    break;
                default:
                    LogInfo("Add Task TimeUniy Type Error...");
                    break;

            }
        }
        nowTime = GetUTCMilliseconds();
        PETimeTask newTask = new PETimeTask(tid, callback, nowTime + delay, delay, count);

        bool isRep = false;
        for (int i = 0; i < taskTimeLst.Count; i++) {
            if (taskTimeLst[i].tid == tid) {
                taskTimeLst[i] = newTask;
                isRep = true;
                break;
            }
        }
        if (!isRep) {
            for (int i = 0; i < tmpTimeLst.Count; i++) {
                if (tmpTimeLst[i].tid == tid) {
                    tmpTimeLst[i] = newTask;
                    isRep = true;
                    break;
                }
            }
        }
        return isRep;
    }
    #endregion
    #region FrameTask
    public int AddFrameTask(Action callback, int delay, int count = 1) {
        int tid = GetTid();
        tmpFrameLst.Add(new PEFrameTask(tid, callback, frameCounter + delay, delay, count));
        tidLst.Add(tid);
        return tid;
    }
    public bool DeleteFrameTask(int tid) {
        bool exist = false;
        for (int i = 0; i < taskFrameLst.Count; i++) {
            PEFrameTask task = taskFrameLst[i];
            if (task.tid == tid) {
                taskFrameLst.RemoveAt(i);
                for (int j = 0; j < tidLst.Count; j++) {
                    if (tidLst[j] == tid) {
                        tidLst.RemoveAt(j);
                        break;
                    }
                }
                exist = true;
                break;
            }
        }

        if (!exist) {
            for (int i = 0; i < tmpFrameLst.Count; i++) {
                PEFrameTask task = tmpFrameLst[i];
                if (task.tid == tid) {
                    tmpFrameLst.RemoveAt(i);
                    for (int j = 0; j < tidLst.Count; j++) {
                        if (tidLst[j] == tid) {
                            tidLst.RemoveAt(j);
                            break;
                        }
                    }
                    exist = true;
                    break;
                }
            }
        }
        return exist;
    }
    public bool ReplaceFrameTask(int tid, Action callback, int delay, int count = 1) {
        PEFrameTask newTask = new PEFrameTask(tid, callback, frameCounter + delay, delay, count);
        bool isRep = false;
        for (int i = 0; i < taskFrameLst.Count; i++) {
            if (taskFrameLst[i].tid == tid) {
                taskFrameLst[i] = newTask;
                isRep = true;
                break;
            }
        }
        if (!isRep) {
            for (int i = 0; i < tmpFrameLst.Count; i++) {
                if (tmpFrameLst[i].tid == tid) {
                    tmpFrameLst[i] = newTask;
                    isRep = true;
                    break;
                }
            }
        }
        return isRep;
    }
    #endregion
    public void SetLog(Action<string> log) {
        taskLog = log;
    }
    #region Tool Methonds
    private int GetTid() {
        lock (obj) {
            tid += 1;
            //安全代码，以防万一
            while (true) {
                if (tid == int.MaxValue) {
                    tid = 0;
                }
                bool used = false;
                for (int i = 0; i < tidLst.Count; i++) {
                    if (tid == tidLst[i]) {
                        used = true;
                        break;
                    }
                }
                if (!used) {
                    break;
                } else {
                    tid += 1;
                }
            }
        }
        return tid;
    }
    private void RecycleTid() {
        for (int i = 0; i < recTidLst.Count; i++) {
            int tid = recTidLst[i];

            for (int j = 0; j < recTidLst.Count; j++) {
                if (tidLst[j] == tid) {
                    tidLst.RemoveAt(j);
                    break;
                }
            }
        }
        recTidLst.Clear();
    }
    private void LogInfo(string info) {
        if (taskLog != null) {
            taskLog(info);
        }
    }
    private double GetUTCMilliseconds() {
        TimeSpan ts = DateTime.UtcNow - startDateTime;
        return ts.TotalMilliseconds;
    }
    #endregion
}
