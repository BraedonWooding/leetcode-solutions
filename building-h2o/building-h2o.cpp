#include <mutex>
#include <condition_variable>

class H2O {
public:
    inline void notify()
    {
        if (hydrogenCount == 0 && oxygenCount == 0) {
            hydrogenCount = 2;
            oxygenCount = 1;
        }
        cv.notify_all();
    }

    void hydrogen(function<void()> releaseHydrogen) {
        {
            std::unique_lock<std::mutex> lock(mtx);
            cv.wait(lock, [this](){ return hydrogenCount > 0 && oxygenCount > 0; });
            hydrogenCount--;
        }
        
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();
        notify();
    }

    void oxygen(function<void()> releaseOxygen) {
        {
            std::unique_lock<std::mutex> lock(mtx);
            cv.wait(lock, [this](){ return hydrogenCount == 0 && oxygenCount > 0; });
            oxygenCount--;
        }

        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
        notify();
    }

    std::mutex mtx;
    std::condition_variable cv;
    volatile int oxygenCount = 1;
    volatile int hydrogenCount = 2;
};