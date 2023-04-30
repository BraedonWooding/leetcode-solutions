#include <mutex>
#include <condition_variable>

class semaphore {
public:
    semaphore ()
        : hydrogenCount(2), oxygenCount(1) {}

    inline void notify()
    {
        std::unique_lock<std::mutex> lock(mtx);
        if (hydrogenCount == 0 && oxygenCount == 0) {
            hydrogenCount = 2;
            oxygenCount = 1;
            cv.notify_all();
        }
    }

    inline void waitOxygen()
    {
        std::unique_lock<std::mutex> lock(mtx);
        cv.wait(lock, [this](){ return hydrogenCount == 0 && oxygenCount > 0; });

        printf("|%d|", oxygenCount);
        oxygenCount--;
    }

    inline void waitHydrogen()
    {
        std::unique_lock<std::mutex> lock(mtx);
        cv.wait(lock, [this](){ return hydrogenCount > 0 && oxygenCount > 0; });

        printf("{%d}", hydrogenCount);
        hydrogenCount--;
        if (hydrogenCount == 0) cv.notify_all();
    }

private:
    std::mutex mtx;
    std::condition_variable cv;
    volatile int oxygenCount;
    volatile int hydrogenCount;
};

class H2O {
public:
    H2O() {
        
    }

    void hydrogen(function<void()> releaseHydrogen) {
        lck.waitHydrogen();
        
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();

        lck.notify();
    }

    void oxygen(function<void()> releaseOxygen) {
        lck.waitOxygen();

        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();

        lck.notify();
    }

    semaphore lck {};
};